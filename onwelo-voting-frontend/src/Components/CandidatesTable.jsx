import React, { useState } from 'react';
import { useSelector } from 'react-redux';
import { candidates } from '../store/votingSlice';
import './VotingSummaryPanel.scss';

export const CandidatesTable = () => {

    const candidatesList = useSelector(candidates);

    const [newCandidateName, setNewCandidateName] = useState('');

    const handleCandidateChange = (event) => {
        setNewCandidateName(event.target.value)
    }

    const handleSubmitCandidate = (event) => {
        event.preventDefault();
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: newCandidateName })
        };
        fetch('https://localhost:44341/addCandidate', requestOptions)
            .then(response => {
                response.text();
                setNewCandidateName('');
            });
    }

    return <div className="voting-summary-panel__candidates-table">
        <form onSubmit={handleSubmitCandidate}>
            <input type="text"
                placeholder='Candidate'
                onChange={handleCandidateChange}
                value={newCandidateName} />
            <input type="submit" value="Submit" />
        </form>
        <table>
            <caption>
                Candidates
            </caption>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Votes</th>
                </tr>
            </thead>
            <tbody>
                {candidatesList && candidatesList.map(candidate => {
                    return <tr key={candidate.id}>
                        <td>{candidate.name}</td>
                        <td>{candidate.votesCount}</td>
                    </tr>
                })}
            </tbody>
        </table>
    </div>
}