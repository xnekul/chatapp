import { Outlet } from 'react-router';
import './App.css';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { UserProvider } from './Context/useAuth';
import Navbar from './Components/Navbar/Navbar';

function App() {
    return (
        <>
            <UserProvider>
                <Navbar />
                <Outlet />
                <ToastContainer />
            </UserProvider>
        </>
    );
}

export default App;

/*

UseEffect - to load things once
<Link to="address"></> // misto <a href>*/
