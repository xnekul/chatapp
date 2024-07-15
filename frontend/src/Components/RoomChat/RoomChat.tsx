import React, { useEffect, useState } from 'react';
import { useOutletContext } from 'react-router-dom';
import MessageForm from '../Message/MessageForm';
import MessageList from '../Message/MessageList';
import { MessageGet } from '../../Models/Message';
import { messageGetAPI } from '../../Services/MessageService';

interface Props {}

const RoomChat = (props: Props) => {
    const ticker = useOutletContext<string>();
    const [messageValues, setMessageValues] = useState<MessageGet[]>([]);

    const MINUTE_MS = 1000;

    useEffect(() => {
        const interval = setInterval(() => {
            getMessage();
            console.log('LOADING MESSAGES');
            console.log(messageValues);
        }, MINUTE_MS);

        return () => clearInterval(interval);
    }, []);

    const getMessage = () => {
        messageGetAPI(ticker)
            .then((res) => {
                if (res?.data) {
                    setMessageValues(res?.data);
                }
            })
            .catch((e) => {
                setMessageValues([]);
            });
    };

    return (
        <>
            <div>
                <MessageList messageValues={messageValues} />
            </div>
            <div>
                <MessageForm roomId={ticker} updateMessages={getMessage} />
            </div>
        </>
    );
};

export default RoomChat;
