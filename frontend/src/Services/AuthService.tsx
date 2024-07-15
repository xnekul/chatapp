import axios from 'axios';
import { handleError } from '../Helpers/ErrorHandle';
import { UserProfileToken } from '../Models/User';

const api = 'http://192.168.75.127:5234/api/';

export const loginAPI = async (username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + 'account/login', {
            username: username,
            password: password,
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const registerAPI = async (email: string, username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + 'account/register', {
            email: email,
            username: username,
            password: password,
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};
