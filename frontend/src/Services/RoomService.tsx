import axios from 'axios';
import { RoomGet, RoomPost } from '../Models/Room';
import { handleError } from '../Helpers/ErrorHandle';
import { api_url } from './api';

const api = api_url + 'room/';

export const roomPostAPI = async (name: string) => {
    try {
        const data = await axios.post<RoomPost>(api + `${name}`, {});
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const roomGetAPI = async () => {
    try {
        const data = await axios.get<RoomGet[]>(api);
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const roomGetByIdAPI = async (id: number) => {
    try {
        const data = await axios.get<RoomGet>(api + `${id}`);
        return data;
    } catch (error) {
        handleError(error);
    }
};
