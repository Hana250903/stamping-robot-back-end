﻿namespace StampingRobot.API.ViewModels.ResponseModels
{
    public class ResponseModel
    {
        public int HttpCode { get; set; } = 200;
        public string Message { get; set; } = "";
        public int? Id { get; set; }
    }
}
