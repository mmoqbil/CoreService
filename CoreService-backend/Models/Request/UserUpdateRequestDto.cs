namespace CoreService_backend.Models.Request;


public class UserUpdateRequestDto
{
    public string userId { get; set; }
}

public class UserNameUpdateRequestDto : UserUpdateRequestDto
{
    public string newUserName { get; set; }
}

public class EmailUpdateRequestDto : UserUpdateRequestDto
{
    public string newEmail { get; set; }
}

public class PasswordUpdateRequestDto : UserUpdateRequestDto
{
    public string newPassword { get; set; }
    public string currentPassword { get; set; }

}

