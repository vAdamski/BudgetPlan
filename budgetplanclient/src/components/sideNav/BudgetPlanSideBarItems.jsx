import {useNavigate} from "react-router-dom";
import PropTypes from "prop-types";
import {useState} from "react";

const BudgetPlanSideBarItems = ({budgetPlanId, budgetPlanName}) => {

    const [expanded, setExpanded] = useState(false);

    const toggleClassName = expanded ? 'arrow_drop_up' : 'arrow_drop_down';

    const navigate = useNavigate();

    function handleClick(path) {
        navigate(path);
    }

    function handleExpand() {
        setExpanded(!expanded);
    }

    return (
        <>
            <div style={{
                borderTop: '1px solid #e0e0e0',
                borderBottom: '1px solid #e0e0e0',
            }}>
                <div className={'navbar-item-budget-plan'}>
                    <span className="material-symbols-outlined">account_balance_wallet</span>
                    <a>{budgetPlanName}</a>
                    <span className="material-symbols-outlined" onClick={handleExpand}>{toggleClassName}</span>
                </div>
                {
                    expanded && (
                        <>
                            <div className={'navbar-item'} onClick={() => handleClick(`/${budgetPlanId}/Dashboard`)}>
                                <span className="material-symbols-outlined">category</span>
                                <a>Pulpit</a>
                            </div>
                            <div className={'navbar-item'}
                                 onClick={() => handleClick(`/${budgetPlanId}/Plans`)}>
                                <span className="material-symbols-outlined">list</span>
                                <a>Plany</a>
                            </div>
                            <div className={'navbar-item'}
                                 onClick={() => handleClick(`/${budgetPlanId}/TransactionCategory`)}>
                                <span className="material-symbols-outlined">category</span>
                                <a>Kategorie</a>
                            </div>
                            <div className={'navbar-item'} onClick={() => handleClick(`/${budgetPlanId}/BudgetPlanSettings`)}>
                                <span className="material-symbols-outlined">settings</span>
                                <a>Ustawienia</a>
                            </div>
                        </>
                    )
                }
            </div>
        </>
    );
}

BudgetPlanSideBarItems.propTypes = {
    budgetPlanId: PropTypes.string.isRequired,
    budgetPlanName: PropTypes.string.isRequired
}

export default BudgetPlanSideBarItems;