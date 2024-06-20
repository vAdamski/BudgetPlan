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
                <div className="page">
                    <div className={'sidebar'}>
                        <SideNavigationBar/>
                    </div>

                    <main>
                        <article className={'content'}>
                                <Routes>
                                    <Route path="/" element={<HomePage/>}/>
                                    <Route path="/TransactionCategory" element={<TransactionCategory/>}/>
                                    <Route path="/authentication/login-callback" element={<LoginCallback/>}></Route>
                                </Routes>
                        </article>
                    </main>
                </div>
            </Router>
        </AuthProvider>
    );
};

export default App;