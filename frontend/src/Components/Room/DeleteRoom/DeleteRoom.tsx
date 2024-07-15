import React, { SyntheticEvent } from 'react';

interface Props {
    roomValue: string;
    onRoomDelete: (e: SyntheticEvent) => void;
}

const DeleteRoom: React.FC<Props> = ({ roomValue, onRoomDelete }: Props): JSX.Element => {
    return (
        <div>
            <form onSubmit={onRoomDelete}>
                <input hidden={true} readOnly={true} value={roomValue} />
                <button>X</button>
            </form>
        </div>
    );
};

export default DeleteRoom;
