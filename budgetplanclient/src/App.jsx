import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { AuthProvider } from './AuthProvider';
import LoginCallback from './LoginCallback';
import HomePage from './HomePage';

const App = () => {
    return (
        <AuthProvider>
            <Router>
                <Routes>
                    <Route path="/authentication/login-callback" element={<LoginCallback />} />
                    <Route path="/" element={<HomePage />} />
                </Routes>
            </Router>
        </AuthProvider>
    );
};

export default App;