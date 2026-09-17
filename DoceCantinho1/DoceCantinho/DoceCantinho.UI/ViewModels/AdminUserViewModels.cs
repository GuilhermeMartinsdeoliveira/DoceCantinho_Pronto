namespace DoceCantinho.UI.ViewModels
{
    public class CreateUserViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Role { get; set; } = "Usuário";
        public System.Collections.Generic.List<string> Roles { get; set; } = new();
    }

    public class EditUserViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string Role { get; set; } = string.Empty;
        public System.Collections.Generic.List<string> Roles { get; set; } = new();
    }
}
