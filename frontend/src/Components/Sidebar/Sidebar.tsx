import React from 'react';
import { Link } from 'react-router-dom';

interface Props {}

const Sidebar = (props: Props) => {
    return (
        <>
            <div>Sidebar</div>
            <Link to="room-info">
                <h6>Info</h6>
            </Link>
            <Link to="messages">
                <h6>Chat</h6>
            </Link>
        </>
    );
};

export default Sidebar;
