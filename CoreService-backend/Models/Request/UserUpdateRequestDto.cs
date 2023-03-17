namespace CoreService_backend.Models.Request;


public class UserNameUpdateRequestDto
{
    public string newUserName { get; set; }
}

public class EmailUpdateRequestDto
{
    public string newEmail { get; set; }
}

public class PasswordUpdateRequestDto
{
    public string newPassword { get; set; }
    public string currentPassword { get; set; }

}

