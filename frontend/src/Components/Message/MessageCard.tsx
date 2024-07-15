import React from 'react';
import { MessageGet } from '../../Models/Message';

interface Props {
    messageValue: MessageGet;
}

const MessageCard = ({ messageValue }: Props) => {
    return <div>{messageValue.content}</div>;
};

export default MessageCard;
