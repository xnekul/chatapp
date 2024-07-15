import React, { SyntheticEvent } from 'react';
import CardRoom from '../CardRoom/CardRoom';
import { RoomGet } from '../../../Models/Room';
import { v4 as uuidv4 } from 'uuid';

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
                        <CardRoom key={uuidv4()} roomValue={value} onRoomDelete={onRoomDelete} />
                    );
                })
            ) : (
                <h1>No results</h1>
            )}
        </div>
    );
};

export default ListRoom;
