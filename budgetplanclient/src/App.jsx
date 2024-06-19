import './App.css';
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import {AuthProvider} from './services/authProvider.jsx';
import LoginCallback from './services/loginCallback.jsx';
import HomePage from './components/pages/homePage/HomePage.jsx';
import SideNavigationBar from "./components/sideNav/SideNavigationBar.jsx";
import TransactionCategory from "./components/pages/categories/TransactionCategory.jsx";


const App = () => {
    return (
        <AuthProvider>
            <Router>
                <div className="container">
                    <div className={'sideNavBar'}>
                        <SideNavigationBar/>
                    </div>
                    <div className={'content'}>
                        <Routes>
                            <Route path="/" element={<HomePage/>}/>
                            <Route path="/TransactionCategory" element={<TransactionCategory/>}/>
                            <Route path="/authentication/login-callback" element={<LoginCallback/>}></Route>
                        </Routes>
                    </div>
                </div>
            </Router>
        </AuthProvider>
    );
};

export default App;