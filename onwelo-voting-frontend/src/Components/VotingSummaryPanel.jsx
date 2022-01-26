import React from 'react';

import { CandidatesTable } from './CandidatesTable';
import { VotersTable } from './VotersTable';
import './VotingSummaryPanel.scss';

export const VotingSummaryPanel = () => {
    return <div className='voting-summary-panel__tables-container'>
        <VotersTable />
        <CandidatesTable />
    </div>
}