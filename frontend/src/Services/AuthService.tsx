import axios from 'axios';
import { handleError } from '../Helpers/ErrorHandle';
import { UserProfileToken } from '../Models/User';

const api = api_url + 'account/';

export const loginAPI = async (username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + 'login', {
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
        const data = await axios.post<UserProfileToken>(api + 'register', {
            email: email,
            username: username,
            password: password,
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};
