import './plans.css';
import PropTypes from "prop-types";
import useBudgetPlanBasesApi from "../../../services/api/budgetPlanBases.jsx";
import {useEffect, useState} from "react";
import TableHeader from "./TableHeader.jsx";
import MainCategoryRow from "./MainCategoryRow.jsx";

function BudgetPlanBaseTableView({budgetPlanBaseId}) {
    const {getBudgetPlanBasesForBudgetPlan} = useBudgetPlanBasesApi();
    const [budgetPlanBase, setBudgetPlanBase] = useState(null);

    useEffect(() => {
        const fetchBudgetPlanBases = async () => {
            const data = await getBudgetPlanBasesForBudgetPlan(budgetPlanBaseId);
            setBudgetPlanBase(data);
        }

        fetchBudgetPlanBases();
    }, [budgetPlanBaseId]);

    return (
        <>
            <table>
                <TableHeader dateFrom={'2024-05-10'} dateTo={'2024-06-09'}/>
                <tbody>
                {budgetPlanBase && budgetPlanBase.transactionCategoryDetailsViewDtos ? (
                    budgetPlanBase.transactionCategoryDetailsViewDtos.map(transactionCategoryDetailsViewDto =>
                        (
                            <MainCategoryRow key={transactionCategoryDetailsViewDto.id}
                                             mainCategory={transactionCategoryDetailsViewDto}/>
                        )
                    )
                ) : (
                    <tr>
                        <td colSpan="2">Loading...</td>
                    </tr>
                )}
                </tbody>
            </table>
        </>
    );
}

BudgetPlanBaseTableView.propTypes = {
    budgetPlanBaseId: PropTypes.string.isRequired,
}

export default BudgetPlanBaseTableView;