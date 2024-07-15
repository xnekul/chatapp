import React, { SyntheticEvent } from 'react';
import DeleteRoom from '../DeleteRoom/DeleteRoom';
import { RoomGet } from '../../../Models/Room';
import { Link } from 'react-router-dom';

interface Props {
    roomValue: RoomGet;
    onRoomDelete: (e: SyntheticEvent) => void;
}

const CardRoom: React.FC<Props> = ({ roomValue, onRoomDelete }: Props): JSX.Element => {
    return (
        <>
            <h4>Room name: {roomValue.name}</h4>
            <DeleteRoom roomValue={roomValue.name} onRoomDelete={onRoomDelete} />
            <Link to={`/room/${roomValue.id}/room-info`}>Go to Room</Link>
        </>
    );
};

export default CardRoom;
