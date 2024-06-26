import {useContext, useEffect, useState} from 'react';
import ToggleButton from './ToggleButton';
import SidebarLogo from './SidebarLogo';
import SidebarItem from './SidebarItem';
import SidebarDropdown from './SidebarDropdown';
import SidebarFooter from './SidebarFooter';
import useBudgetPlansApi from '../../services/api/budgetPlans';
import {AuthContext} from '../../services/authProvider';
import {useNavigate} from "react-router-dom";

function SideNav({handleToggleSideNav}) {
    const {user} = useContext(AuthContext);
    const {getBudgetPlans} = useBudgetPlansApi();
    const [budgetPlans, setBudgetPlans] = useState([]);

    const navigate = useNavigate();

    function handleClick(path) {
        navigate(path);
    }

    useEffect(() => {
        const fetchData = async () => {
            if (user) {
                try {
                    const data = await getBudgetPlans();
                    setBudgetPlans(data.budgetPlanDtos);
                } catch (error) {
                    console.error('Failed to fetch budget plans:', error);
                }
            } else {
                setBudgetPlans([]);
            }
        };

        fetchData();
    }, [user]);

    return (
        <>
            <div className="d-flex">
                <ToggleButton handleToggleSideNav={handleToggleSideNav}/>
                <SidebarLogo/>
            </div>
            <ul className="sidebar-nav">
                {user ? (
                    <>
                        <SidebarItem onClick={() => handleClick("/")} icon="lni-home">Strona główna</SidebarItem>
                        {budgetPlans.map((budgetPlan) => (
                            <SidebarDropdown
                                key={budgetPlan.id}
                                id={`multi`}
                                target={`multi`}
                                icon="lni-layout"
                                label={budgetPlan.name}
                            >
                                <SidebarItem onClick={() => handleClick(`/${budgetPlan.id}/Dashboard`)}>Pulpit</SidebarItem>
                                <SidebarItem onClick={() => handleClick(`/${budgetPlan.id}/Plans`)}>Plany</SidebarItem>
                                <SidebarItem onClick={() => handleClick(`/${budgetPlan.id}/TransactionCategory`)}>Kategorie</SidebarItem>
                                <SidebarItem onClick={() => handleClick(`/${budgetPlan.id}/BudgetPlanSettings`)}>Ustawienia</SidebarItem>
                            </SidebarDropdown>
                        ))}
                        <SidebarItem onClick={() => handleClick("/Settings")} icon="lni-cog">Ustawienia</SidebarItem>
                    </>
                ) : (
                    <>
                    </>
                )}
            </ul>
            <SidebarFooter/>
        </>
    );
}

export default SideNav;