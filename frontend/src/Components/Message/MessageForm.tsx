import React from 'react';
import * as Yup from 'yup';
import { useAuth } from '../../Context/useAuth';
import { yupResolver } from '@hookform/resolvers//yup';
import { useForm } from 'react-hook-form';
import { messagePostAPI } from '../../Services/MessageService';

interface Props {
    roomId: string;
}

type MessageFormsInputs = {
    content: string;
};

const validation = Yup.object().shape({
    content: Yup.string().required('Text is required.'),
});

const MessageForm = ({ roomId }: Props) => {
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<MessageFormsInputs>({ resolver: yupResolver(validation) });

    const handleMessagePost = (form: MessageFormsInputs) => {
        messagePostAPI(roomId, form.content);
    };

    return (
        <>
            <form onSubmit={handleSubmit(handleMessagePost)}>
                <div>
                    <input type="text" id="username" {...register('content')} />
                    {errors.content ? <p>{errors.content.message}</p> : ''}
                </div>
                <button type="submit">Send</button>
            </form>
        </>
    );
};

export default MessageForm;
