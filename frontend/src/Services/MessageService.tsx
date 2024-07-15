import axios from 'axios';
import { MessageGet, MessagePost } from '../Models/Message';
import { handleError } from '../Helpers/ErrorHandle';

const api = 'http://192.168.75.127:5234/api/message/';

export const messagePostAPI = async (roomId: string, content: string) => {
    try {
        const data = await axios.post<MessagePost>(api, {
            roomId: roomId,
            content: content,
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const messageGetAPI = async (roomId: string) => {
    try {
        const data = await axios.get<MessageGet[]>(api);
        return data;
    } catch (error) {
        handleError(error);
    }
};
