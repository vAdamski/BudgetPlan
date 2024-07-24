import {useEffect, useState} from 'react';
import {useParams} from "react-router-dom";
import useBudgetPlansApi from "../../../services/api/budgetPlans.jsx";
import SubCategoryList from "./SubCategoryList.jsx";
import AddCategoryForm from "./AddCategoryForm.jsx";

function TransactionCategory() {
    const {budgetPlanId} = useParams();
    const {getTransactionCategoriesForBudget} = useBudgetPlansApi();

    const [budgetPlanTransactionCategories, setBudgetPlanTransactionCategories] = useState([]);
    const [action, setAction] = useState(false);


    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const data = await getTransactionCategoriesForBudget(budgetPlanId);
                console.log(data);

                setBudgetPlanTransactionCategories(data.transactionCategoryDtos || []);
            } catch (error) {
                setBudgetPlanTransactionCategories([]);
                console.error('Error fetching transaction categories:', error);
            }
        };

        fetchCategories();

        if (action) {
            setAction(false);
        }
    }, [action]);

    const handleAction = () => {
        setAction(true);
    };

    return (
        <div className={'container-fluid'}>
            <div className={'row g-3'}>
                {budgetPlanTransactionCategories.map(category => (
                    <div key={category.id} className={'col-3'}>
                        <div className={'card'} style={{
                            height: '100%'
                        }}>
                            <div className={'card-header'}>
                                <div className={'d-flex justify-content-between'}>
                                    <b>{category.transactionCategoryName}</b>
                                    <button className="btn btn-danger btn-sm" type={'button'}>Usuń</button>
                                </div>
                            </div>
                            <div className={'card-body'}>
                                <SubCategoryList
                                    subCategories={category.transactionCategoryDtos}
                                    mainCategoryId={category.id}
                                    handleAction={handleAction}
                                />
                            </div>
                        </div>
                    </div>
                ))}
                <AddCategoryForm budgetPlanId={budgetPlanId} handleAction={handleAction}/>

            </div>
        </div>
    );
}

export default TransactionCategory;