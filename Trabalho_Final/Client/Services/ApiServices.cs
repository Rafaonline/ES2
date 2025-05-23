using System.ComponentModel.DataAnnotations;

namespace Client.Services;
using System.Net.Http.Json;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Obter uma mensagem de teste
    public async Task<string> GetMessageAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponse>("api/Test/hello");
        return response?.Message ?? "Erro ao obter a mensagem";
    }

    // Obter todos os eventos
    public async Task<List<EventDto>> GetEventsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<EventDto>>("api/Event") ?? new List<EventDto>();
    }
    
    public async Task<List<string>> GetEventCategoriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<string>>("api/Event/categories");
    }
    
    public async Task<List<string>> GetLocalidadesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<string>>("api/Event/localidades");
    }
    
    public async Task<List<string>> GetDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<string>>("api/Event/datas");
    }
   
    public async Task<bool> ParticiparEventoAsync(int userId, int eventId, int ticketId)
    {
        var registration = new
        {
            UserId = userId,
            EventId = eventId,
            TicketId = ticketId
        };

        var response = await _httpClient.PostAsJsonAsync("api/event/participate", registration);
        return response.IsSuccessStatusCode;
    }

    
    public async Task<List<EventDto>> GetEventsByParticipantAsync(int userId)
    {
        var response = await _httpClient.GetAsync($"api/Event/participant/{userId}");

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<List<EventDto>>();
            return result ?? new List<EventDto>();
        }

        return new List<EventDto>();
    }
    public async Task<EventReportDto> GetRelatorioEventosAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<EventReportDto>("api/Event/EventReport");
        return response!;
    }
    public async Task<EventDetailReportDto?> GetRelatorioEventoAsync(int eventId)
    {
        return await _httpClient
            .GetFromJsonAsync<EventDetailReportDto>($"api/Event/EventReport/{eventId}");
    }

    
    public async Task<bool> CancelarParticipacaoAsync(int userId, int eventId)
    {
        var response = await _httpClient.DeleteAsync($"api/Event/{eventId}/participants/{userId}");

        return response.IsSuccessStatusCode;
    }
    
    // Obter um evento específico por ID
    public async Task<EventDto?> GetEventByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<EventDto>($"api/Event/{id}");
    }

    // Criar um evento
    public async Task<int?> CreateEventAsync(EventDto newEvent)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Event", newEvent);

        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<CreateEventResponse>();
        return result?.eventId;
    }
    
    // Atualizar um evento existente
    public async Task<bool> UpdateEventAsync(int id, EventDto updatedEvent)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Event/{id}", updatedEvent);
        return response.IsSuccessStatusCode;
    }

    
    // Criar os Tickets para o Evento
    
    public async Task<List<EventTicketDto>> GetTicketsByEventIdAsync(int eventId)
    {
        return await _httpClient.GetFromJsonAsync<List<EventTicketDto>>($"api/EventTicket/{eventId}");
    }
    
    public async Task<bool> CreateTicketAsync(EventTicketDto ticket)
    {
        var response = await _httpClient.PostAsJsonAsync("api/EventTicket", ticket);
        return response.IsSuccessStatusCode;
    }
    
    public async Task<bool> UpdateTicketAsync(int id, EventTicketDto updatedTicket)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/EventTicket/{id}", updatedTicket);
        return response.IsSuccessStatusCode;
    }
    
    public async Task<bool> DeleteTicketAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/EventTicket/{id}");
        return response.IsSuccessStatusCode;
    }

    
    // Criar as Atividades para o Evento
    
    public async Task<List<ActivityDto>> GetActivitiesByEventIdAsync(int eventId)
    {
        return await _httpClient.GetFromJsonAsync<List<ActivityDto>>($"api/Activity/event/{eventId}");
    }
    public async Task<bool> CreateActivityAsync(ActivityDto activity)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Activity", activity);
        return response.IsSuccessStatusCode;
    }
    
    public async Task<UserUpdateDto> GetUserAsync(int userId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/User/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erro ao obter utilizador {userId}: {response.StatusCode}");
                return new UserUpdateDto();
            }
            var user = await response.Content.ReadFromJsonAsync<UserUpdateDto>();
            return user ?? new UserUpdateDto();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exceção ao obter utilizador {userId}: {ex.Message}");
            return new UserUpdateDto();
        }
    }
    public async Task<bool> UpdateActivityAsync(int id, ActivityDto updatedActivity)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Activity/{id}", updatedActivity);
        return response.IsSuccessStatusCode;
    }
    
    public async Task<bool> DeleteActivityAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Activity/{id}");
        return response.IsSuccessStatusCode;
    }


    public async Task<string> UpdateUserAsync(UserUpdateDto userUpdate)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/User/{userUpdate.Id}", userUpdate);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Resposta do PUT api/User/{userUpdate.Id}: {content}, Status: {response.StatusCode}");
            if (response.IsSuccessStatusCode)
            {
                return content.Contains("sucesso", StringComparison.OrdinalIgnoreCase) ? content : "Erro ao atualizar perfil.";
            }
            return content;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exceção no PUT api/User/{userUpdate.Id}: {ex.Message}");
            return $"Erro ao atualizar perfil: {ex.Message}";
        }
    }
    
    private class ApiResponse
    {
        public string Message { get; set; }
    }

    
    // DTO correspondente
    public class EventDto
    {
        public int Id { get; set; }
        public int OrganizerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Category { get; set; } = string.Empty;
        public object EventDate { get; set; }
    }
    
    public class EventDetailReportDto
    {
        public object Duration;

        public int Id { get; set; }
        public int OrganizerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string? Category { get; set; }
        
        public int TotalParticipants { get; set; }
        public int TotalActivities   { get; set; }
        
        public double DurationHours { get; set; }
    }

    
    public class EventTicketDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string TicketType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public string Description { get; set; } = string.Empty;
    }
    public class EventReportDto
    {
        public int TotalEventos { get; set; }
        public string EventoMaisCaro { get; set; } = string.Empty;
        public string EventoComMaisParticipantes { get; set; } = string.Empty;
        public string EventoComMaisAtividades { get; set; } = string.Empty;
        public string EventoMaisLongo { get; set; } = string.Empty;
        public string EventoMaisProximo { get; set; } = string.Empty;
        public double MediaParticipantes { get; set; }
        public Dictionary<string, int> Categorias { get; set; } = new();
        public Dictionary<string, int> Localidades { get; set; } = new();
    }
    

    
    private class CreateEventResponse
    {
        public string message { get; set; }
        public int eventId { get; set; }
    }
    
    public class ActivityDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ActivityStartDate { get; set; }
        public DateTime ActivityEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class UserUpdateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }


}