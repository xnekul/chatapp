import React from 'react';
import * as Yup from 'yup';
import { useAuth } from '../../Context/useAuth';
import { yupResolver } from '@hookform/resolvers//yup';
import { useForm } from 'react-hook-form';

interface Props {}

type RegisterFormsInputs = {
    email: string;
    userName: string;
    password: string;
};

const validation = Yup.object().shape({
    email: Yup.string().required('Email is required.'),
    userName: Yup.string().required('Username is required.'),
    password: Yup.string().required('Password is required.'),
});

const RegisterPage = (props: Props) => {
    const { registerUser } = useAuth();
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<RegisterFormsInputs>({ resolver: yupResolver(validation) });

    const handleRegister = (form: RegisterFormsInputs) => {
        registerUser(form.email, form.userName, form.password);
        console.log(form);
    };

    return (
        <>
            <h1>Sign in to your account</h1>
            <form onSubmit={handleSubmit(handleRegister)}>
                <div>
                    <label htmlFor="email">Email</label>
                    <input type="text" id="email" placeholder="Email" {...register('email')} />
                    {errors.email ? <p>{errors.email.message}</p> : ''}
                </div>
                <div>
                    <label htmlFor="username">Username</label>
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
                <button type="submit">Register</button>
                <p>
                    Don’t have an account yet? <a href="#">Register TODO</a>
                </p>
            </form>
        </>
    );
};

export default RegisterPage;
