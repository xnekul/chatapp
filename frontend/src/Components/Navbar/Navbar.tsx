import React from 'react';
import { Link } from 'react-router-dom';
import { useAuth } from '../../Context/useAuth';

type Props = {};

const Navbar = (props: Props) => {
    const { isLoggedIn, user, logout } = useAuth();
    return (
        <div>
            <Link to="/">Home</Link>
            {isLoggedIn() ? (
                <>
                    <a onClick={logout}>Logout</a>
                </>
            ) : (
                <>
                    <Link to="/login">Login</Link>
                    <Link to="/register">Register</Link>
                </>
            )}
        </div>
    );
};

export default Navbar;
