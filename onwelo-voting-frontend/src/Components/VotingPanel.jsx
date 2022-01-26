import React, { useState } from 'react';
import { useSelector } from 'react-redux';
import { candidates, voters } from '../store/votingSlice';
import './VotingPanel.scss';

export const VotingPanel = () => {
    const candidatesList = useSelector(candidates);
    const votersList = useSelector(voters);

    const [voteWhoId, setVoteWhoId] = useState();
    const [voteForId, setVoteForId] = useState();

    const handleVoteWhoChange = (event) => {
        setVoteWhoId(+event.target.value)
    }

    const handleVoteForChange = (event) => {
        setVoteForId(+event.target.value)
    }

    const submitVote = () => {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ voterId: voteWhoId, candidateId: voteForId })
        };
        fetch('https://localhost:44341/submitVote', requestOptions)
            .then(response => {
                response.text();
                setVoteWhoId("");
                setVoteForId("");
            });
    }

    return <div className='voting-panel__container'>
        <header>
            Vote!
        </header>
        <div>
            <select name="voteWho" id="voteWho" onChange={handleVoteWhoChange} value={voteWhoId}>
                <option value="" disabled selected hidden> I am</option>
                {votersList.map(voter => {
                    if (voter.hasVoted) return;
                    return <option value={voter.id} key={voter.id}>{voter.name}</option>;
                })}

            </select>

            <select name="voteFor" id="voteFor" onChange={handleVoteForChange} value={voteForId}>
                <option value="" disabled selected hidden> I vote for</option>
                {candidatesList.map(candidate => {
                    return <option value={candidate.id} key={candidate.id}>{candidate.name}</option>;
                })}
            </select>
            <button disabled={!voteWhoId || !voteForId} onClick={submitVote}>Submit!</button>
        </div>
    </div>
}