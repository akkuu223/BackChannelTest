using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", async context =>
{
    using var client = new HttpClient();

    // Define the request URL
    var url = "https://gusea4d02.onb.pro.ukg.dev/api/auth/logout";

    // Define the body of the POST request
    var requestBody = new
    {
        logout_token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InFubms0SGoxdGdhcWtBUVVxRWYtViJ9.eyJ0YSI6ImdjYzEwMDFfZ3FzX3JlY3J1aXRtZW50X25ld191YXQiLCJ0aWQiOiJvcmdfZ0NwNnVFUHdqZDNMRHlzbCIsImdsb2JhbF90ZW5hbnRfaWQiOiI1NDU3NjYxMi1kNzcxLTQ5MDAtOThhMS1hYTQyYjljNzU3YWUiLCJ1a2dfdXNlcl9pZCI6ImRkNzJmM2YzLWU2MzUtNDI3ZS05YmY4LTRiMTljZGNlMWUyZSIsImdpdmVuX25hbWUiOiJtb3VzdW1pIiwiZmFtaWx5X25hbWUiOiJrdW1hcmkiLCJuaWNrbmFtZSI6Im1vdXN1bWkua3VtYXJpIiwicHJlZmVycmVkX3VzZXJuYW1lIjoibW91c3VtaS5rdW1hcmlAdWtnLmNvbSIsIm5hbWUiOiJtb3VzdW1pLmt1bWFyaUB1a2cuY29tIiwicGljdHVyZSI6Imh0dHBzOi8vcy5ncmF2YXRhci5jb20vYXZhdGFyLzA1MTA2M2VhOTY2M2ZmZTcwYzAyMDI1YTI5NjJhOGE2P3M9NDgwJnI9cGcmZD1odHRwcyUzQSUyRiUyRmNkbi5hdXRoMC5jb20lMkZhdmF0YXJzJTJGbW8ucG5nIiwibG9jYWxlIjoiZW4iLCJ1cGRhdGVkX2F0IjoiMjAyNS0wNi0xMFQwNjo0NDo0MC4xMjdaIiwiZW1haWwiOiJtb3VzdW1pLmt1bWFyaUB1a2cuY29tIiwiZW1haWxfdmVyaWZpZWQiOmZhbHNlLCJpc3MiOiJodHRwczovL3NpZ25pbi1zdGFnaW5nLXRlc3QudWtnLmRldi8iLCJhdWQiOiJhNDExMWQwMy01NTE4LTQ4ZjEtYmFjYi0xMDNlNzJjOTNmNDEiLCJzdWIiOiJhdXRoMHxkZDcyZjNmMy1lNjM1LTQyN2UtOWJmOC00YjE5Y2RjZTFlMmUiLCJpYXQiOjE3NDk1Mzc4OTIsImV4cCI6MTc0OTU2NjY5Miwic2lkIjoiVHlRTWd6eGJaVmtMTTB5el9NTGFFWWNCTms1eG16YkEiLCJvcmdfaWQiOiJvcmdfZ0NwNnVFUHdqZDNMRHlzbCJ9.Z4ULaA3q888OO0CEn6P1ap0NnJo7VipcV9sfwU0NZmVNkcSYevG7A3m740j6SHwNfl42VSqEmD46MXj7C5-bnxqPlvtwUeKz4S8lEl8U1H2DQEtg9Dp2pFPdfSS07aZp39Y_hge8hp8VWwHKGtCNvNUVYmNNgUXoV-4PVA-GVq6hqTyVap3SkOeHsI8YFW4Du4CbKawelz2qisYSnyMeFwajz5ZhI_yDpdDGdrX_YL3DJHnhPl6CC4f_2nXEaFjH5zWy4pvTLIqxHxbGEF29qHTe2BJlodsS0oJ7lFs2VafYOiPWSMuNmXUNbErXT9yYyGVYYt-36UxvmwHFF-okag"
    };

    var json = System.Text.Json.JsonSerializer.Serialize(requestBody);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    // Optional: Add more headers if needed
    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

    // Set default headers for the client
    client.DefaultRequestHeaders.Add("Accept", "application/json");


    // Send POST request
    var response = await client.PostAsync(url, content);

    // Read response content if needed
    var responseBody = await response.Content.ReadAsStringAsync();

    // Output result to browser
    var output = $"Status Code: {response.StatusCode}\nResponse Body: {responseBody}";
    Console.WriteLine(output);

    await context.Response.WriteAsync(output);
});

app.Run();