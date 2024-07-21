import React, { SyntheticEvent } from 'react';
import CardRoom from '../CardRoom/CardRoom';
import { RoomGet } from '../../../Models/Room';

interface Props {
    roomValues: RoomGet[];
    onRoomDelete: (e: SyntheticEvent) => void;
}

const ListRoom: React.FC<Props> = ({ roomValues, onRoomDelete }: Props): JSX.Element => {
    return (
        <div>
            {roomValues.length > 0 ? (
                roomValues.map((value) => {
                    return (
                        <CardRoom key={value.id} roomValue={value} onRoomDelete={onRoomDelete} />
                    );
                })
            ) : (
                <h1>No results</h1>
            )}
        </div>
    );
};

export default ListRoom;
