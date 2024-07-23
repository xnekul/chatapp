import React from 'react';
import * as Yup from 'yup';
import { yupResolver } from '@hookform/resolvers//yup';
import { useForm } from 'react-hook-form';
import { roomPostAPI } from '../../../Services/RoomService';

interface Props {
    updateRooms: () => void;
}

type RoomFormsInputs = {
    content: string;
};

const validation = Yup.object().shape({
    content: Yup.string().required('Text is required.'),
});

const RoomForm = ({ updateRooms }: Props) => {
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<RoomFormsInputs>({ resolver: yupResolver(validation) });

    const handleRoomPost = (form: RoomFormsInputs) => {
        roomPostAPI(form.content);
        updateRooms();
    };

    return (
        <>
            <form onSubmit={handleSubmit(handleRoomPost)}>
                <div>
                    <input type="text" id="username" {...register('content')} />
                    {errors.content ? <p>{errors.content.message}</p> : ''}
                </div>
                <button type="submit">Create</button>
            </form>
        </>
    );
};

export default RoomForm;
