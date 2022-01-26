import React, { useState } from 'react';
import { useSelector } from 'react-redux';
import { voters } from '../store/votingSlice';
import './VotingSummaryPanel.scss';

export const VotersTable = () => {

    const votersList = useSelector(voters);

    const [newVoterName, setNewVoterName] = useState('');

    const handleVoterChange = (event) => {
        setNewVoterName(event.target.value)
    }

    const handleSubmitVoter = (event) => {
        event.preventDefault();
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: newVoterName })
        };
        fetch('https://localhost:44341/addVoter', requestOptions)
            .then(response => {
                response.text();
                setNewVoterName('');
            });
    }

    return <div className="voting-summary-panel__votes-table">
        <form onSubmit={handleSubmitVoter}>
            <input type="text"
                placeholder='Voter'
                onChange={handleVoterChange}
                value={newVoterName} />
            <input type="submit" value="Submit" />
        </form>
        <table>
            <caption>
                Voters
            </caption>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Has voted</th>
                </tr>
            </thead>
            <tbody>
                {votersList && votersList.map(voter => {
                    return <tr key={voter.id}>
                        <td>{voter.name}</td>
                        <td>{voter.hasVoted ? "y" : "n"}</td>
                    </tr>
                })}
            </tbody>
        </table>
    </div>
}