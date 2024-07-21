import React, { SyntheticEvent } from 'react';
import Card from '../Card/Card';

interface Props {
    searchResult: object[];
    onRoomAdd: (e: SyntheticEvent) => void;
}

const Cardlist: React.FC<Props> = ({ searchResult, onRoomAdd }: Props): JSX.Element => {
    return (
        <div>
            {searchResult.length > 0 ? (
                searchResult.map((result) => {
                    return (
                        <Card id={'TBD'} key={'TBD'} searchResult={result} onRoomAdd={onRoomAdd} />
                    );
                })
            ) : (
                <h1>No results</h1>
            )}
        </div>
    );
};

export default Cardlist;
