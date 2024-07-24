import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { AuthProvider } from './services/authProvider';
import LoginCallback from './services/loginCallback';
import HomePage from './components/pages/homePage/HomePage';
import TransactionCategory from "./components/pages/categories/TransactionCategory";
import Dashboard from "./components/pages/dashboard/Dashboard";
import Plans from "./components/pages/plans/Plans";
import BudgetPlanSettings from "./components/pages/settings/BudgetPlanSettings";
import SideNav from "./components/sideNav/SideNav";
import { useState } from 'react';

const App = () => {
    const [isExpanded, setIsExpanded] = useState(true);

    const toggleSideNav = () => {
        // setIsExpanded(!isExpanded);
    }

    const sideNavClass = isExpanded ? 'expand' : '';

    const contentClasses = isExpanded ? 'main p-3 expand' : 'main p-3';

    return (
        <AuthProvider>
            <Router>
                <div className='wrapper'>
                    <aside id='sidebar' className={sideNavClass}>
                        <SideNav handleToggleSideNav={toggleSideNav} />
                    </aside>

                    <div className={contentClasses}>
                        <Routes>
                            <Route path="/" element={<HomePage />} />
                            <Route path="/:budgetPlanId/Dashboard" element={<Dashboard />} />
                            <Route path="/:budgetPlanId/TransactionCategory" element={<TransactionCategory />} />
                            <Route path="/:budgetPlanId/Plans" element={<Plans />} />
                            <Route path="/:budgetPlanId/BudgetPlanSettings" element={<BudgetPlanSettings />} />
                            <Route path="/authentication/login-callback" element={<LoginCallback />} />
                        </Routes>
                    </div>
                </div>
            </Router>
        </AuthProvider>
    );
};

export default App;