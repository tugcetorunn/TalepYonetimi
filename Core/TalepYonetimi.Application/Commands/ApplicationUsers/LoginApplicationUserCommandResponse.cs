﻿using TalepYonetimi.Application.Dtos;

namespace TalepYonetimi.Application.Commands.ApplicationUsers
{
    public class LoginApplicationUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public Token Token { get; set; }
    }
}
