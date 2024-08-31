import {useContext, useEffect, useState} from 'react';
import ToggleButton from './ToggleButton';
import SidebarLogo from './SidebarLogo';
import SidebarItem from './SidebarItem';
import SidebarDropdown from './SidebarDropdown';
import SidebarFooter from './SidebarFooter';
import useBudgetPlansApi from '../../services/api/budgetPlans';
import {AuthContext} from '../../services/authProvider';
import {useNavigate} from "react-router-dom";
import BudgetPlanCreateModal from "./BudgetPlanCreateModal.jsx";

function SideNav({handleToggleSideNav}) {
    const {user} = useContext(AuthContext);
    const {getBudgetPlans, createBudgetPlan} = useBudgetPlansApi();
    const [budgetPlans, setBudgetPlans] = useState([]);
    const [show, setShow] = useState(false);
    const [handleUpdate, setHandleUpdate] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const navigate = useNavigate();

    function handleClick(path) {
        navigate(path);
    }

    const createBudgetPlanFunc = async (budgetPlanDto) => {
        try {
            await createBudgetPlan(budgetPlanDto);
            setHandleUpdate(!handleUpdate);
        } catch (error) {
            console.error('Error creating budget plan:', error);
        }
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
    }, [user, handleUpdate]);

    return (
        <>
            <div className="d-flex align-content-center justify-content-center">
                <SidebarLogo/>
            </div>
            <ul className="sidebar-nav">
                {user ? (
                    <>
                        {/*<SidebarItem onClick={() => handleClick("/")} icon="home">Strona główna</SidebarItem>*/}
                        {budgetPlans.map((budgetPlan) => (
                            <SidebarDropdown
                                key={budgetPlan.id}
                                id={`multi`}
                                target={`multi`}
                                icon="currency_exchange"
                                label={budgetPlan.name}
                            >
                                <SidebarItem icon={'data_usage'} onClick={() => handleClick(`/${budgetPlan.id}/Dashboard`)}>Pulpit</SidebarItem>
                                <SidebarItem icon={'table_rows'} onClick={() => handleClick(`/${budgetPlan.id}/Plans`)}>Plany</SidebarItem>
                                <SidebarItem icon={'category'} onClick={() => handleClick(`/${budgetPlan.id}/TransactionCategory`)}>Kategorie</SidebarItem>
                                <SidebarItem icon={'settings'} onClick={() => handleClick(`/${budgetPlan.id}/BudgetPlanSettings`)}>Ustawienia</SidebarItem>
                            </SidebarDropdown>
                        ))}
                        <SidebarItem onClick={handleShow} icon="add">Utwórz Plan</SidebarItem>
                        {/*<SidebarItem onClick={() => handleClick("/Settings")} icon="lni-cog">Ustawienia</SidebarItem>*/}
                    </>
                ) : (
                    <>
                    </>
                )}
            </ul>
            <BudgetPlanCreateModal show={show} handleClose={handleClose} createBudgetPlan={createBudgetPlanFunc}/>
            <SidebarFooter/>
        </>
    );
}

export default SideNav;