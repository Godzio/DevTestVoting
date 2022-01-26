import './App.scss';
import { VotingPanel } from './Components/VotingPanel';
import { VotingSummaryPanel } from './Components/VotingSummaryPanel';
import { UseSignalR } from './Hooks/useSignalR';

const App = () => {
  UseSignalR();

  return (
    <div className='app-container'>
      <header>
        Voting app
      </header>
      <VotingSummaryPanel />
      <VotingPanel />
    </div>
  );
}

export default App;