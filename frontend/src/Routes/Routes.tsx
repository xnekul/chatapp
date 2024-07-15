import { createBrowserRouter } from 'react-router-dom';
import App from '../App';
import HomePage from '../Pages/HomePage/HomePage';
import SearchPage from '../Pages/SearchPage/SearchPage';
import RoomPage from '../Pages/RoomPage/RoomPage';
import RoomChat from '../Components/RoomChat/RoomChat';
import RoomInfo from '../Components/RoomInfo/RoomInfo';
import LoginPage from '../Pages/LoginPage/LoginPage';
import RegisterPage from '../Pages/RegisterPage/RegisterPage';
import ProtectedRoute from './ProtectedRoute';

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            { path: '', element: <HomePage /> },
            {
                path: 'search',
                element: (
                    <ProtectedRoute>
                        <SearchPage />
                    </ProtectedRoute>
                ),
            },
            { path: 'login', element: <LoginPage /> },
            { path: 'register', element: <RegisterPage /> },

            {
                path: 'room/:ticker',
                element: (
                    <ProtectedRoute>
                        <RoomPage />
                    </ProtectedRoute>
                ),
                children: [
                    { path: 'room-info', element: <RoomInfo /> },
                    { path: 'messages', element: <RoomChat /> },
                ],
            },
        ],
    },
]);
