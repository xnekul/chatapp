using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Room;
using api.Models;

namespace api.Mappers
{
    public static class RoomMapper
    {
        public static RoomDto ToRoomDto(this Room roomModel)
        {
            return new RoomDto{
                Id = roomModel.Id,
                Name = roomModel.Name,
            };
        }
        public static Room ToRoomFromCreateDto(this CreateRoomDto roomDto)
        {
            return new Room
            {
                Name = roomDto.Name,
            };
        }
    }
}