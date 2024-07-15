import React from 'react';
import * as Yup from 'yup';
import { useAuth } from '../../Context/useAuth';
import { yupResolver } from '@hookform/resolvers//yup';
import { useForm } from 'react-hook-form';

interface Props {}

type LoginFormsInputs = {
    userName: string;
    password: string;
};

const validation = Yup.object().shape({
    userName: Yup.string().required('Username is required.'),
    password: Yup.string().required('Password is required.'),
});

const LoginPage = (props: Props) => {
    const { loginUser } = useAuth();
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<LoginFormsInputs>({ resolver: yupResolver(validation) });

    const handleLogin = (form: LoginFormsInputs) => {
        loginUser(form.userName, form.password);
    };

    return (
        <>
            <h1>Sign in to your account</h1>
            <form onSubmit={handleSubmit(handleLogin)}>
                <div>
                    <label htmlFor="email">Username</label>
                    <input
                        type="text"
                        id="username"
                        placeholder="Username"
                        {...register('userName')}
                    />
                    {errors.userName ? <p>{errors.userName.message}</p> : ''}
                </div>
                <div>
                    <label htmlFor="password">Password</label>
                    <input
                        type="password"
                        id="password"
                        placeholder="••••••••"
                        {...register('password')}
                    />
                    {errors.password ? <p>{errors.password.message}</p> : ''}
                </div>
                <div>
                    <a href="#">Forgot password?</a>
                </div>
                <button type="submit">Sign in</button>
                <p>
                    Don’t have an account yet? <a href="#">Sign up</a>
                </p>
            </form>
        </>
    );
};

export default LoginPage;
