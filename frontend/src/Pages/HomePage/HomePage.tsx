import React from 'react';
import { Link } from 'react-router-dom';

interface Props {}

const HomePage = (props: Props) => {
    return (
        <div>
            <Link to="/search">Go to chats</Link>
        </div>
    );
};

export default HomePage;
