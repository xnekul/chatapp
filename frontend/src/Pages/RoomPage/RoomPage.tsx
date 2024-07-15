import React, { useEffect, useState } from 'react';
import Sidebar from '../../Components/Sidebar/Sidebar';
import RoomDashboard from '../../Components/RoomDashboard/RoomDashboard';
import { useParams } from 'react-router-dom';
import { roomGetByIdAPI } from '../../Services/RoomService';
import { RoomGet } from '../../Models/Room';

interface Props {}

const RoomPage = (props: Props) => {
    let { ticker } = useParams();
    const [roomValue, setRoomValue] = useState<RoomGet | null>();

    useEffect(() => {
        getRoom();
    }, []);

    const getRoom = () => {
        roomGetByIdAPI(Number(ticker))
            .then((res) => {
                if (res?.data) {
                    setRoomValue(res?.data);
                }
            })
            .catch((e) => {
                setRoomValue(null);
            });
    };

    roomGetByIdAPI(1);
    return roomValue ? (
        <>
            <div>{roomValue.name}</div>
            <Sidebar />
            <RoomDashboard ticker={ticker!} />
        </>
    ) : (
        <>
            <h2>Room not found</h2>
        </>
    );
};

export default RoomPage;
