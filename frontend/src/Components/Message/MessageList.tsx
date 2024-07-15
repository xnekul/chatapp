import React from 'react';
import { MessageGet } from '../../Models/Message';
import { v4 as uuidv4 } from 'uuid';
import MessageCard from './MessageCard';

interface Props {
    messageValues: MessageGet[];
}

const MessageList = ({ messageValues }: Props) => {
    return (
        <div>
            {messageValues.length > 0 ? (
                messageValues.map((value) => {
                    return <MessageCard key={uuidv4()} messageValue={value} />;
                })
            ) : (
                <h1>No messages {':('}</h1>
            )}
        </div>
    );
};

export default MessageList;
