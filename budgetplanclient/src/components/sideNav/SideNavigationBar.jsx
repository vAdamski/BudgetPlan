import './SideNavigationBar.css';
import {useContext, useEffect, useState} from 'react';
import {AuthContext} from '../../services/authProvider.jsx';
import UserProfileInfoListItem from "./UserProfileInfoListItem.jsx";
import useBudgetPlansApi from "../../services/api/budgetPlans.jsx";
import NavBarItem from "./NavBarItem.jsx";
import BudgetPlanSideBarItems from "./BudgetPlanSideBarItems.jsx";

function SideNavigationBar() {
    const {user, login, logout} = useContext(AuthContext);
    const {getBudgetPlans} = useBudgetPlansApi();

    const [budgetPlans, setBudgetPlans] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            if (user) {
                try {
                    const data = await getBudgetPlans();
                    setBudgetPlans(data.budgetPlanDtos);
                } catch (error) {
                    console.error("Failed to fetch budget plans:", error);
                }
            } else {
                setBudgetPlans([]);
            }
        };

        fetchData();
    }, [user]);

    return (
        <>
            <div className={'top-nav-bar'}>
                <div className={'app-brand'}>
                    <a>Twój budżet</a>
                </div>
                <div className={'nav-bar-toggle'}>
                    <span className="material-symbols-outlined">chevron_left</span>
                </div>
            </div>
            <div>
                <nav>
                    {
                        user ? (
                            <>
                                <NavBarItem name={'Strona głowna'} iconName={'home'} path={'/'}/>

                                {budgetPlans.map((budgetPlan) => (
                                    <div key={budgetPlan.id}>
                                        <BudgetPlanSideBarItems budgetPlanId={budgetPlan.id} budgetPlanName={budgetPlan.name}/>
                                    </div>
                                ))}

                                <div className={'navbar-item'} onClick={logout}>
                                    <span className="material-symbols-outlined">logout</span>
                                    <a>Wyloguj</a>
                                </div>
                                <UserProfileInfoListItem/>
                            </>
                        ) : (
                            <>
                                <div className={'navbar-item'} onClick={login}>
                                    <span className="material-symbols-outlined">login</span>
                                    <a>Zaloguj</a>
                                </div>
                            </>
                        )
                    }
                </nav>
            </div>
        </>
    );
}

export default SideNavigationBar;