using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Room;
using api.Entities;

namespace api.ModelMappers
{
    public static class RoomModelMapper
    {
        public static RoomDto ToRoomDto(this RoomEntity roomModel)
        {
            return new RoomDto
            {
                Id = roomModel.Id,
                Name = roomModel.Name,
            };
        }
        public static RoomEntity ToRoomFromCreateDto(this CreateRoomRequestDto roomDto)
        {
            return new RoomEntity
            {
                Name = roomDto.Name,
            };
        }
        public static RoomEntity ToRoomFromUpdateDto(this UpdateRoomRequestDto roomDto, int id)
        {
            return new RoomEntity { Id = id, Name = roomDto.Name, };
        }
    }
}