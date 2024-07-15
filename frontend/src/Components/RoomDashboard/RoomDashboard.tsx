import React from 'react';
import { Outlet } from 'react-router';
import { RoomGet } from '../../Models/Room';

interface Props {
    ticker: string;
}

const RoomDashboard = ({ ticker }: Props) => {
    return (
        <>
            <Outlet context={ticker} />
        </>
    );
};

export default RoomDashboard;
