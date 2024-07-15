import React, { SyntheticEvent } from 'react';
import './Card.css';
import AddRoom from '../Room/AddRoom/AddRoom';

interface Props {
    id: string;
    searchResult: object;
    onRoomAdd: (e: SyntheticEvent) => void;
}

const Card: React.FC<Props> = ({ id, searchResult, onRoomAdd }: Props): JSX.Element => {
    return (
        <div className="card">
            <img alt="picture" />
            <div className="details">
                <h2>Header</h2>
                <p>{id}</p>
            </div>
            <div>
                <p className="info">Lorem ipsum dolor sit amet.</p>
                <AddRoom onRoomAdd={onRoomAdd} name={id} />
            </div>
        </div>
    );
};

export default Card;
