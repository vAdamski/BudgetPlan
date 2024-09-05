import {useEffect, useState} from 'react';
import {useParams} from "react-router-dom";
import useBudgetPlansApi from "../../../services/api/budgetPlans.jsx";
import SubCategoryList from "./SubCategoryList.jsx";
import AddCategoryForm from "./AddCategoryForm.jsx";
import useTransactionCategoriesApi from "../../../services/api/transactionCategories.jsx";

function TransactionCategory() {
    const {budgetPlanId} = useParams();
    const {getTransactionCategoriesForBudget} = useBudgetPlansApi();
    const {deleteTransactionCategory} = useTransactionCategoriesApi();

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

    const handleDeleteCategory = (id) => {
        deleteTransactionCategory(id)
            .then(() => {
                handleAction();
            })
            .catch((error) => {
                console.error('Error deleting transaction category:', error);
            });
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
                                    <button className="btn btn-danger btn-sm" type={'button'} onClick={() => handleDeleteCategory(category.id)}>Usuń</button>
                                </div>
                            </div>
                            <div className={'card-body'}>
                                <SubCategoryList
                                    subCategories={category.transactionCategoryDtos}
                                    mainCategoryId={category.id}
                                    handleDeleteCategory={handleDeleteCategory}
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