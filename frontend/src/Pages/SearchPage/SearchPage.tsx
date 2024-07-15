import React, { ChangeEvent, SyntheticEvent, useEffect, useState } from 'react';
import Search from '../../Components/Search/Search';
import ListRoom from '../../Components/Room/ListRoom/ListRoom';
import Cardlist from '../../Components/CardList/Cardlist';
import { Link } from 'react-router-dom';
import { RoomGet } from '../../Models/Room';
import { roomGetAPI } from '../../Services/RoomService';

interface Props {}

const SearchPage = (props: Props) => {
    const [search, setSearch] = useState<string>('');
    const [searchResult, setSearchResult] = useState<RoomGet[]>([]);
    const [serverError, setServerError] = useState<string>('');
    const [roomValues, setRoomValues] = useState<RoomGet[]>([]);

    useEffect(() => {
        getRoom();
    }, []);

    const getRoom = () => {
        roomGetAPI()
            .then((res) => {
                if (res?.data) {
                    setRoomValues(res?.data);
                }
            })
            .catch((e) => {
                setRoomValues([]);
            });
    };

    const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
        console.log(e);
    };

    const onSearchSubmit = (e: SyntheticEvent) => {
        e.preventDefault();
        console.log(e);
        const result = 'Not implemented';
        if (typeof result == 'string') {
            setServerError(result);
        } else if (Array.isArray(result /*.data*/)) {
            setSearchResult(result);
        }
    };

    const onRoomAdd = (e: any) => {
        e.preventDefault();
        console.log(e);
        const exists = roomValues.find((value) => value === e.target[0].value);
        if (exists) return;
        const updatedRoomValues = [...roomValues, e.target[0].value];
        setRoomValues(updatedRoomValues);
    };

    const onRoomDelete = (e: any) => {
        e.preventDefault();
        console.log(e);
        const updatedRoomValues = roomValues.filter((value) => {
            return value !== e.target[0].value;
        });
        setRoomValues(updatedRoomValues);
    };

    return (
        <>
            <Link to="/">Go To Homepage</Link>
            <Search
                onSearchSubmit={onSearchSubmit}
                search={search}
                handleSearchChange={handleSearchChange}
            />
            {serverError && <h1>{serverError}</h1>}
            <ListRoom roomValues={roomValues} onRoomDelete={onRoomDelete} />
            {/*<Cardlist searchResult={searchResult} onRoomAdd={onRoomAdd} />*/}
        </>
    );
};

export default SearchPage;
