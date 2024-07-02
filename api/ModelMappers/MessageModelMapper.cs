using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Message;
using api.Entities;

namespace api.ModelMappers
{
    public static class MessageModelMapper
    {
        public static MessageDto ToMessageDto(this MessageEntity messageModel)
        {
            return new MessageDto
            {
                Id = messageModel.Id,
                Content = messageModel.Content,
                Date = messageModel.Date,
                RoomId = messageModel.RoomId,
                AuthorId = messageModel.AuthorId,
            };
        }
        public static MessageEntity ToMessageFromCreateDto(this CreateMessageRequestDto messageDto, string AuthorId)
        {
            return new MessageEntity
            {
                Content = messageDto.Content,
                Date = DateTime.UtcNow,
                RoomId = messageDto.RoomId,
                AuthorId = AuthorId,
            };
        }
        public static MessageEntity ToMessageFromUpdateDto(this UpdateMessageRequestDto messageDto, int id)
        {
            return new MessageEntity
            {
                Id = id,
                Content = messageDto.Content,
                Date = DateTime.UtcNow,
                RoomId = messageDto.RoomId,
                AuthorId = messageDto.AuthorId,
            };
        }
    }
}
