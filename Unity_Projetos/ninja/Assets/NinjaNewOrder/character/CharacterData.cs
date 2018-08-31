using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CharacterData : MonoBehaviour {
    /// <summary>
    /// Walk velocity
    /// </summary>
    [SerializeField] string _characterVelocity;
    [SerializeField] string _characterVelocityRunMultPliyer;
    [SerializeField] string _gamerName;
    [SerializeField] string _energyBar;
    [SerializeField] string _Life;

    public int Life()
    {
        return Convert.ToInt32(_Life);
    }
    public void Life( int life)
    {
        _Life = Convert.ToString(life);
    }
    public void LifeIncrease( int value)
    {
        Life(Life() + value);
    }
    public double CharacterVelocity()
    {
        return Convert.ToDouble(_characterVelocity);
    }
    public void CharacterVelocity( double velocity)
    {
        _characterVelocity = Convert.ToString(velocity);
    }
    public double GamerVelocityMultplyer()
    {
        return Convert.ToDouble(_characterVelocityRunMultPliyer);
    }
    public void GamerVelocityMultplyer(double velocity)
    {
        _characterVelocityRunMultPliyer = Convert.ToString(velocity);
    }
    public double GamerEnergyBar()
    {
        return Convert.ToDouble(_characterVelocity);
    }
    public void GamerEnergyBar(double energyBar)
    {
        _gamerName = Convert.ToString(energyBar);
    }
}
