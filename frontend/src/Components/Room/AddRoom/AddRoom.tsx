import React, { SyntheticEvent } from 'react';

interface Props {
    onRoomAdd: (e: SyntheticEvent) => void;
    name: string;
}

const AddRoom: React.FC<Props> = ({ onRoomAdd, name }: Props): JSX.Element => {
    return (
        <form onSubmit={onRoomAdd}>
            <input readOnly={true} hidden={true} value={name} />
            <button type="submit">Add</button>
        </form>
    );
};

export default AddRoom;
