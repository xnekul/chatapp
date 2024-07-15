export type MessageGet = {
    id: number;
    content: string;
    roomId: string;
    userId: string;
};

export type MessagePost = {
    content: string;
    roomId: string;
    userId: string;
};
