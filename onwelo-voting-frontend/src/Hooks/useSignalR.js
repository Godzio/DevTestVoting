import { HubConnectionBuilder } from '@microsoft/signalr';
import { useEffect } from 'react';
import { useDispatch } from 'react-redux'
import { setCandidates, setAll, setVoters } from '../store/votingSlice';

export const UseSignalR = () => {
    const dispatch = useDispatch();

    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl('https://localhost:44341/hubs/liveData')
            .withAutomaticReconnect()
            .build();

        connection.start()
            .then(result => {
                console.log('Connected!');

                connection.on('BroadcastAll', message => {
                    dispatch(setAll(message));
                });

                connection.on('BroadcastCandidates', message => {
                    dispatch(setCandidates(message));
                });

                connection.on('BroadcastVoters', message => {
                    dispatch(setVoters(message));
                });
            })
            .catch(e => console.log('Connection failed: ', e));

        console.log(connection);
    }, [dispatch]);
}