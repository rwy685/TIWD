using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildResourceHandler
{

    // 자원 부족 리스트 계산

    public bool CheckResourceShortage(BuildData data, Inventory inv, out Dictionary<ItemData, int> shortfall)
    {
        shortfall = new();

        foreach (var req in data.requirements)
        {
            int has = inv.Count(req.item);

            if (has < req.amount)
                shortfall[req.item] = req.amount - has;
        }

        return shortfall.Count == 0;
    }

    // 건축 재료 한번에 소모
    public void ConsumeBuildResources(BuildData data, Inventory inv)
    {
        foreach (var req in data.requirements)
        {
            inv.ConsumeMultiple(req.item, req.amount);
        }
    }
}


